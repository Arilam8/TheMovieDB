using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Utils.APIUtils.Models;
using Utils.APIUtils;
using WPFApplication.Models;
using System.Windows.Controls;
using WPFApplication.Views;
using System.Windows;
using WPFApplication.ViewModels;
using Utils.DownloadUtils;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing;
using Image = System.Drawing.Image;

namespace WPFApplication.Utils
{
    static public class Utils
    {
        static public async Task MovieDTOsToMovieModelsAsync(ObservableCollection<MovieModel> movieModels, List<MovieDTO> movieDTOs)
        {
            foreach (MovieDTO movieDTO in movieDTOs)
            {
                byte[] poster = await Task.Run(() =>
                {
                    return DownloadUtils.DownloadImage(Constant.URL_IMAGE_THEMOVIEDB + movieDTO.Poster);
                });
                List<MovieTypeDTO> movieTypeDTOs = new List<MovieTypeDTO>();
                APIResponseMultiple<MovieTypeDTO> response = await WebAPIManager.GetListMovieTypesByIdMovieAsync(movieDTO.Id);
                if (response.Succeeded)
                    movieTypeDTOs = response.Datas.ToList();
                Application.Current.Dispatcher.Invoke((Action)(delegate
                {
                    movieModels.Add(new MovieModel(movieDTO, poster, movieTypeDTOs));
                }));
            }
        }

        static public List<MovieTypeModel> MovieTypeDTOsToMovieTypeModels(List<MovieTypeDTO> movieTypeDTOs)
        {
            List<MovieTypeModel> movieTypeModels = new List<MovieTypeModel>();
            if (movieTypeDTOs != null)
            {
                foreach (MovieTypeDTO movieTypeDTO in movieTypeDTOs)
                    movieTypeModels.Add(new MovieTypeModel(movieTypeDTO));
            }
            return movieTypeModels;
        }

        static public async Task LightActorDTOsToLightActorModels(ObservableCollection<LightActorModel> lightActorModels, List<LightActorDTO> lightActorDTOs)
        {
            if (lightActorDTOs != null)
            {
                foreach (LightActorDTO lightActorDTO in lightActorDTOs)
                {
                    if (lightActorDTO.Roles.Count <= 0)
                    {
                        LightActorModel actorModel = new LightActorModel();
                        await Task.Run(() =>
                        {
                            actorModel = new LightActorModel(lightActorDTO);
                        });
                        Application.Current.Dispatcher.Invoke((Action)(delegate
                        {
                            lightActorModels.Add(actorModel);
                        }));
                    }
                    else
                    {
                        foreach (RoleDTO roleDTO in lightActorDTO.Roles)
                        {
                            LightActorModel actorModel = new LightActorModel();
                            await Task.Run(() =>
                            {
                                actorModel = new LightActorModel(lightActorDTO, new RoleModel(roleDTO));
                            });
                            Application.Current.Dispatcher.Invoke((Action)(delegate
                            {
                                lightActorModels.Add(actorModel);
                            }));
                        }
                    }
                }
            }
        }

        static public async Task CommentDTOsToCommentModels(ObservableCollection<CommentModel> commentModels, List<CommentDTO> commentDTOs)
        {
            if (commentDTOs != null)
            {
                foreach (CommentDTO commentDTO in commentDTOs)
                {
                    CommentModel commentModel = new CommentModel();
                    await Task.Run(() =>
                    {
                        commentModel = new CommentModel(commentDTO);
                    });
                    Application.Current.Dispatcher.Invoke((Action)(delegate
                    {
                        commentModels.Add(commentModel);
                    }));
                }
            }
        }

        static public float GetAverageRateCommentModels(List<CommentModel> commentModels)
        {
            float averageRate = 0;
            foreach (CommentModel commentModel in commentModels.Where(c => c.Valid == true))
                    averageRate += commentModel.Rate;
            if (averageRate > 0)
                return Convert.ToSingle(Math.Round(averageRate / commentModels.Where(c => c.Valid == true).ToList().Count, 2));
            else
                return averageRate;
        }

        static public BitmapImage MovieTypeDTOToImageMovieType(int idMovieType)
        {
            switch (idMovieType)
            {
                case Constant.ID_MOVIE_TYPE_ADVENTURE:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_ADVENTURE, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_FANTASY:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_FANTASY, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_ANIMATION:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_ANIMATION, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_DRAMA:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_DRAMA, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_HORROR:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_HORROR, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_ACTION:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_ACTION, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_COMEDY:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_COMEDY, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_HISTORY:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_HISTORY, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_WESTERN:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_WESTERN, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_THRILLER:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_THRILLER, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_CRIME:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_CRIME, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_DOCUMENTARY:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_DOCUMENTARY, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_SCIENCE_FICTION:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_SCIENCE_FICTION, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_MYSTERY:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_MYSTERY, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_MUSIC:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_MUSIC, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_ROMANCE:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_ROMANCE, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_FAMILY:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_FAMILY, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_WAR:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_WAR, UriKind.Relative));
                case Constant.ID_MOVIE_TYPE_TV_MOVIE:
                    return new BitmapImage(new Uri(Constant.URL_IMAGE_MOVIE_TYPE_TV_MOVIE, UriKind.Relative));
                default:
                    return new BitmapImage();
            }
        }

        static public byte[] DownloadBackdropMovie(string urlBackdrop)
        {
            if (string.IsNullOrWhiteSpace(urlBackdrop))
                return null;
            MemoryStream memoryStream = new MemoryStream(DownloadUtils.DownloadImage(Constant.URL_IMAGE_THEMOVIEDB + urlBackdrop));
            Bitmap bitmap = new Bitmap(memoryStream);
            if(bitmap.Width >= 3840)
                return ResizeImage(Image.FromStream(memoryStream), 3840, 1075, 3.5, true);
            else
                return ResizeImage(Image.FromStream(memoryStream), 1920, 550, 2, true);
        }

        static public byte[] ResizeImage(Image image, int width, int height, double localisation, bool needToFill)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int destinationWidth = 0;
            int destinationHeight = 0;
            int sourceX = 0;
            int sourceY = 0;
            double destinationX = 0;
            double destinationY = 0;
            double nScale = 0;
            double nScaleWidth = 0;
            double nScaleHeight = 0;
            Bitmap bitmap;

            nScaleWidth = ((double)width / (double)sourceWidth);
            nScaleHeight = ((double)height / (double)sourceHeight);
            if (!needToFill)
                nScale = Math.Min(nScaleHeight, nScaleWidth);
            else
            {
                nScale = Math.Max(nScaleHeight, nScaleWidth);
                destinationY = (height - sourceHeight * nScale) / 2;
                destinationX = (width - sourceWidth * nScale) / 2;
            }
            if (nScale > 1)
                nScale = 1;
            destinationWidth = (int)Math.Round(sourceWidth * nScale);
            destinationHeight = (int)Math.Round(sourceHeight * nScale);
            try
            {
                bitmap = new Bitmap(destinationWidth + (int)Math.Round(2 * destinationX), destinationHeight + (int)Math.Round(2 * destinationY));
            }
            catch
            {
                return new byte[0];
            }
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                Rectangle rectangleTo = new Rectangle((int)Math.Round(destinationX), (int)Math.Round(destinationY / localisation), destinationWidth, destinationHeight);
                Rectangle rectangleFrom = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                graphics.DrawImage(image, rectangleTo, rectangleFrom, GraphicsUnit.Pixel);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    return memoryStream.ToArray();
                }
            }
        }

        static public void DisplayLoading(Frame frame, int rowSpan)
        {
            frame.SetValue(Grid.RowSpanProperty, rowSpan);
            frame.Navigate(new LoadView());
            frame.Visibility = Visibility.Visible;
        }

        static public void DisplayError(Frame frame, int rowSpan, MoviesViewModel moviesViewModel, FullMovieViewModel fullMovieViewModel)
        {
            frame.SetValue(Grid.RowSpanProperty, rowSpan);
            frame.Navigate(new ErrorsView(moviesViewModel, fullMovieViewModel));
            frame.Visibility = Visibility.Visible;
        }

        static public void DisplayNoResult(Frame frame, int rowSpan)
        {
            frame.SetValue(Grid.RowSpanProperty, rowSpan);
            frame.Navigate(new NoResultView());
            frame.Visibility = Visibility.Visible;
        }

        static public void CollapsedFrame(Frame frame)
        {
            frame.Visibility = Visibility.Collapsed;
        }
    }
}
