using AMSRSE.DataViewer.DataModels;
using Magatama.Core.Commands;
using Magatama.Core.DataModels;
using Magatama.Core.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.Views
{
    public class BMSSVComparisonView : ViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty FileAProperty =
            DependencyProperty.Register("FileA", typeof(FileModel), typeof(BMSSVComparisonView));

        public static readonly DependencyProperty FileBProperty =
            DependencyProperty.Register("FileB", typeof(FileModel), typeof(BMSSVComparisonView));

        public static readonly DependencyPropertyKey BlocksPropertyKey =
            DependencyProperty.RegisterReadOnly("Blocks", typeof(ObservableCollection<BlockModel>), typeof(BMSSVComparisonView), null);

        public static readonly DependencyProperty BlocksProperty =
            BlocksPropertyKey.DependencyProperty;

        public static readonly DependencyProperty SelectedBlockProperty =
            DependencyProperty.Register("SelectedBlock", typeof(BlockModel), typeof(BMSSVComparisonView), new PropertyMetadata(SelectedBlockPropertyChanged));

        public static readonly DependencyPropertyKey OriginalChunksPropertyKey =
            DependencyProperty.RegisterReadOnly("OriginalChunks", typeof(ObservableCollection<ChunkModel>), typeof(BMSSVComparisonView), null);

        public static readonly DependencyProperty OriginalChunksProperty =
            OriginalChunksPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey ModifiedChunksPropertyKey =
            DependencyProperty.RegisterReadOnly("ModifiedChunks", typeof(ObservableCollection<ChunkModel>), typeof(BMSSVComparisonView), null);

        public static readonly DependencyProperty ModifiedChunksProperty =
            ModifiedChunksPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey CompareFilesCommandPropertyKey =
            DependencyProperty.RegisterReadOnly("CompareFilesCommand", typeof(DelegateCommand), typeof(BMSSVComparisonView), null);

        public static readonly DependencyProperty CompareFilesCommandProperty =
            CompareFilesCommandPropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public FileModel FileA
        {
            get { return (FileModel)GetValue(FileAProperty); }
            set { SetValue(FileAProperty, value); }
        }

        public FileModel FileB
        {
            get { return (FileModel)GetValue(FileBProperty); }
            set { SetValue(FileBProperty, value); }
        }

        public IList Blocks
        {
            get { return (IList)GetValue(BlocksProperty); }
            private set { SetValue(BlocksPropertyKey, value); }
        }

        public BlockModel SelectedBlock
        {
            get { return (BlockModel)GetValue(SelectedBlockProperty); }
            set { SetValue(SelectedBlockProperty, value); }
        }

        public IList OriginalChunks
        {
            get { return (IList)GetValue(OriginalChunksProperty); }
            private set { SetValue(OriginalChunksPropertyKey, value); }
        }

        public IList ModifiedChunks
        {
            get { return (IList)GetValue(ModifiedChunksProperty); }
            private set { SetValue(ModifiedChunksPropertyKey, value); }
        }

        public DelegateCommand CompareFilesCommand
        {
            get { return (DelegateCommand)GetValue(CompareFilesCommandProperty); }
            private set { SetValue(CompareFilesCommandPropertyKey, value); }
        }

        #endregion Properties

        #region Members

        private EditableModelChangeHistoryEntry _compareResults;

        #endregion Members

        #region Ctor

        public BMSSVComparisonView()
        {
            CompareFilesCommand = new DelegateCommand(CompareFiles);

            InitializeComponent(
                relativeXamlPath: "/Views/BMSSVComparisonView.xaml");
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void SelectedBlockPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BMSSVComparisonView view)
                view.UpdateChunks();
        }

        #endregion Dependency Property Callbacks

        #region Methods

        private void CompareFiles(object parameter = null)
        {
            _compareResults = EditableModelChangeHistoryEntry.CompareEditableModel(
                em1: FileA, em2: FileB, includeNonChanged: true);

            ObservableCollection<BlockModel> blocks = new ObservableCollection<BlockModel>();
            EditableModelChangeHistoryEntry blockResults = _compareResults.ChangedItems
                .FirstOrDefault(r => r.Property == "Blocks");

            if (blockResults != null)
            {
                for (int b = 0; b < blockResults.ChangedItems.Count; b++)
                {
                    var blockResult = blockResults.ChangedItems[b];
                    var originalBlock = blockResult.OldValue as BlockModel;
                    var modifiedBlock = blockResult.NewValue as BlockModel;
                    EditableModelChangeHistoryEntry chunkResults = blockResult.ChangedItems
                        .FirstOrDefault(r => r.Property == "Chunks");

                    if (originalBlock != null)
                        EditableModel.SetChangeHistory(originalBlock, blockResult);

                    if (modifiedBlock != null)
                        EditableModel.SetChangeHistory(modifiedBlock, blockResult);

                    blocks.Add(modifiedBlock == null ? originalBlock : modifiedBlock);

                    if (chunkResults != null)
                    {
                        for (int c = 0; c < chunkResults.ChangedItems.Count; c++)
                        {
                            var chunkResult = chunkResults.ChangedItems[c];
                            var originalChunk = chunkResult.OldValue as ChunkModel;
                            var modifiedChunk = chunkResult.NewValue as ChunkModel;

                            if (originalChunk != null)
                                EditableModel.SetChangeHistory(originalChunk, chunkResult);

                            if (modifiedChunk != null)
                                EditableModel.SetChangeHistory(modifiedChunk, chunkResult);
                        }
                    }
                }
            }

            Blocks = blocks;
        }

        private void UpdateChunks()
        {
            if (SelectedBlock == null)
            {
                OriginalChunks = null;
                ModifiedChunks = null;
            }

            else
            {
                EditableModelChangeHistoryEntry chunkResults = EditableModel.GetChangeHistory(SelectedBlock)
                    .ChangedItems.FirstOrDefault(r => r.Property == "Chunks");

                if (chunkResults != null)
                {
                    OriginalChunks = (IList)chunkResults.OldValue;
                    ModifiedChunks = (IList)chunkResults.NewValue;
                }
            }
        }

        #endregion Methods
    }
}
