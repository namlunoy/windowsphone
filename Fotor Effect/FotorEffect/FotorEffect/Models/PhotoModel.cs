using Nokia.Graphics.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace FotorEffect.Models
{
    public class PhotoModel : INotifyPropertyChanged
    {


        public RandomAccessStreamImageSource ImageSource { set; get; }
        private List<IFilter> _filters = new List<IFilter>();
        public List<FilterModel> FilterList { get; set; }

        public WriteableBitmap OriginalBitmap { set; get; }

        public bool IsSaved = true;

        public int Width { get { return OriginalBitmap.PixelWidth; } }
        public int Height { get { return OriginalBitmap.PixelHeight; } }

        public PhotoModel()
        {
            IsChanged = false;
            FilterList = new List<FilterModel>();
        }

        public bool IsChanged { get; set; }
        public bool CanUndo { get { return FilterList.Count > 0; } }
        public async Task ApplyFilterModelAsync(FilterModel f)
        {
            IsChanged = true;
            FilterList.Add(f);
            foreach (var item in f.Components)
                _filters.Add(item);
           
            await ApplyOriginalAsync();
            IsSaved = false;
        }

        private async Task ApplyOriginalAsync()
        {
            OriginalBitmap = new WriteableBitmap(OriginalBitmap.PixelWidth, OriginalBitmap.PixelHeight);
            using (FilterEffect effect = new FilterEffect(ImageSource) { Filters = _filters })
            using (WriteableBitmapRenderer renderer = new WriteableBitmapRenderer(effect, OriginalBitmap))
            {
                await renderer.RenderAsync();
                OriginalBitmap.Invalidate();
            }
        }

        public async Task ApplyRotationFilterAsync(double value)
        {
            RotationFilterModel f = new RotationFilterModel(value);

            IsChanged = true;
            FilterList.Add(f);
            foreach (var item in f.Components)
                _filters.Add(item);

            int h = Math.Max(OriginalBitmap.PixelHeight, OriginalBitmap.PixelWidth);
            int w = Math.Min(OriginalBitmap.PixelHeight, OriginalBitmap.PixelWidth);

            OriginalBitmap = new WriteableBitmap(w, h);

            using (FilterEffect effect = new FilterEffect(ImageSource) { Filters = _filters })
            using (WriteableBitmapRenderer renderer = new WriteableBitmapRenderer(effect, OriginalBitmap))
            {
                await renderer.RenderAsync();
                OriginalBitmap.Invalidate();
            }
        }

        public void AddFilterModel(FilterModel f)
        {
            IsChanged = true;
            FilterList.Add(f);
            foreach (var item in f.Components)
                _filters.Add(item);
        }



        public FilterEffect GetEffect()
        {
            FilterEffect effect = new FilterEffect(ImageSource);
            effect.Filters = _filters;
            return effect;
        }

        public async Task Undo()
        {
            RemoveLastFilter();
            await ApplyOriginalAsync();
        }

        public void RemoveLastFilter()
        {
            if (CanUndo)
            {
                FilterModel listFilter = FilterList[FilterList.Count - 1];
                for (int i = 0; i < listFilter.Components.Count; i++)
                    _filters.RemoveAt(_filters.Count - 1);
                FilterList.RemoveAt(FilterList.Count - 1);
            }
        }





        public async Task<WriteableBitmap> LayHinhThuNho(int side)
        {
            int minSide = Width < Height ? Width : Height;
            Rect rect = new Rect()
            {
                X = (Width - minSide) / 2,
                Y = (Height - minSide) / 2,
                Height = minSide,
                Width = minSide
            };

            _filters.Add(new CropFilter(rect));
            WriteableBitmap bitmap = new WriteableBitmap(side, side);

            using (FilterEffect effect = new FilterEffect(ImageSource))
            {
                effect.Filters = _filters;
                using (WriteableBitmapRenderer render = new WriteableBitmapRenderer(effect, bitmap))
                {
                    await render.RenderAsync();
                    bitmap.Invalidate();
                }
            }

            _filters.RemoveAt(_filters.Count - 1);
            return bitmap;
        }

        public async Task RenderBitmapAsync(WriteableBitmap bitmap)
        {
            using (FilterEffect effect = new FilterEffect(ImageSource) { Filters = _filters })
            using (WriteableBitmapRenderer renderer = new WriteableBitmapRenderer(effect, bitmap))
            {
                await renderer.RenderAsync();
                bitmap.Invalidate();
            }
        }

        public async Task<WriteableBitmap> CropImageAsync(int side)
        {
            int minSide = Width < Height ? Width : Height;
            Rect rect = new Rect()
            {
                X = (Width - minSide) / 2,
                Y = (Height - minSide) / 2,
                Height = minSide,
                Width = minSide
            };
            WriteableBitmap bitmap = new WriteableBitmap(side, side);
            using (FilterEffect effect = new FilterEffect(ImageSource))
            {
                effect.Filters = new IFilter[] { new CropFilter(rect) };

                using (WriteableBitmapRenderer render = new WriteableBitmapRenderer(effect, bitmap))
                {
                    await render.RenderAsync();
                }

            }
            return bitmap;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
