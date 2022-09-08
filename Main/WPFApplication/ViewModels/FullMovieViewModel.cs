using DataTransferObject;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Utils.APIUtils.Models;
using Utils.APIUtils;
using WPFApplication.Models;
using WPFApplication.Commands;
using WPFApplication.Views;
using System.ComponentModel;
using Application = System.Windows.Application;
using Utils.DownloadUtils;
using System.Windows.Controls;

namespace WPFApplication.ViewModels
{
    public class FullMovieViewModel : INotifyPropertyChanged
    {
        #region MEMBER_VARIABLES
        private int _idMovie;
        private FullMovieView _fullmovieView;
        private FullMovieModel _fullMovie;
        private ObservableCollection<LightActorModel> _fullMovieActors = new ObservableCollection<LightActorModel>();
        private ObservableCollection<CommentModel> _fullMovieComments = new ObservableCollection<CommentModel>();
        private APIResponseSingle<FullMovieDTO> _previousResponseFullMovie;
        private APIResponseSingle<FullMovieDTO> _responseFullMovie;
        private APIResponseMultiplePagination<LightActorDTO> _previousResponseLightActors;
        private APIResponseMultiplePagination<LightActorDTO> _responseLightActors;
        private APIResponseMultiplePagination<CommentDTO> _previousResponseComments;
        private APIResponseMultiplePagination<CommentDTO> _responseComments;
        private APIResponseSingle<CommentDTO> _responseComment;
        private double _indexScrollViewerActor;
        private bool _isInsertComment;
        private bool _isLoadLightActors;
        private bool _isLoadComments;
        private int _currentAction;
        public ICommand InsertCommentFullMovieCommand { get; }
        public ICommand ModifyCommentFullMovieCommand { get; }
        public ICommand DeleteCommentFullMovieCommand { get; }
        public ICommand InvalidateCommentFullMovieCommand { get; }
        public ICommand ValidateCommentFullMovieCommand { get; }
        public ICommand SaveModifyCommentFullMovieCommand { get; }
        public ICommand NavigationPreviousScrollViewCommand { get; }
        public ICommand NavigationNextScrollViewCommand { get; }
        public ICommand NavigationFirstPageActorCommand { get; }
        public ICommand NavigationLastPageActorCommand { get; }
        public ICommand NavigationNextPageActorCommand { get; }
        public ICommand NavigationPreviousPageActorCommand { get; }
        public ICommand NavigationFirstPageCommentCommand { get; }
        public ICommand NavigationLastPageCommentCommand { get; }
        public ICommand NavigationNextPageCommentCommand { get; }
        public ICommand NavigationPreviousPageCommentCommand { get; }
        public ICommand CloseFullMovieCommand { get; }
        #endregion

        #region PROPERTIES
        public int IdMovie
        {
            get { return _idMovie; }
            set
            {
                if (_idMovie != value)
                {
                    _idMovie = value;
                    OnPropertyChanaged(nameof(IdMovie));
                }
            }
        }

        public FullMovieView FullMovieView
        {
            get { return _fullmovieView; }
            set
            {
                if (_fullmovieView != value)
                {
                    _fullmovieView = value;
                    OnPropertyChanaged(nameof(FullMovieView));
                }
            }
        }
        
        public FullMovieModel FullMovie
        {
            get { return _fullMovie; }
            set
            {
                if (_fullMovie != value)
                {
                    _fullMovie = value;
                    OnPropertyChanaged(nameof(FullMovie));
                }
            }
        }

        public ObservableCollection<LightActorModel> FullMovieActors
        {
            get { return _fullMovieActors; }
            set
            {
                if (_fullMovieActors != value)
                {
                    _fullMovieActors = value;
                    OnPropertyChanaged(nameof(FullMovieActors));
                }
            }
        }

        public ObservableCollection<CommentModel> FullMovieComments
        {
            get { return _fullMovieComments; }
            set
            {
                if (_fullMovieComments != value)
                {
                    _fullMovieComments = value;
                    OnPropertyChanaged(nameof(FullMovieComments));
                }
            }
        }

        public APIResponseSingle<FullMovieDTO> PreviousResponseFullMovie
        {
            get { return _previousResponseFullMovie; }
            set
            {
                if (_previousResponseFullMovie != value)
                {
                    _previousResponseFullMovie = value;
                    OnPropertyChanaged(nameof(PreviousResponseFullMovie));
                }
            }
        }

        public APIResponseMultiplePagination<LightActorDTO> ResponseLightActors
        {
            get { return _responseLightActors; }
            set
            {
                if (_responseLightActors != value)
                {
                    _responseLightActors = value;
                    OnPropertyChanaged(nameof(ResponseLightActors));
                }
            }
        }

        public APIResponseMultiplePagination<LightActorDTO> PreviousResponseLightActors
        {
            get { return _previousResponseLightActors; }
            set
            {
                if (_previousResponseLightActors != value)
                {
                    _previousResponseLightActors = value;
                    OnPropertyChanaged(nameof(PreviousResponseLightActors));
                }
            }
        }

        public APIResponseMultiplePagination<CommentDTO> ResponseComments
        {
            get { return _responseComments; }
            set
            {
                if (_responseComments != value)
                {
                    _responseComments = value;
                    OnPropertyChanaged(nameof(ResponseComments));
                }
            }
        }

        public APIResponseMultiplePagination<CommentDTO> PreviousResponseComments
        {
            get { return _previousResponseComments; }
            set
            {
                if (_previousResponseComments != value)
                {
                    _previousResponseComments = value;
                    OnPropertyChanaged(nameof(PreviousResponseComments));
                }
            }
        }

        public APIResponseSingle<FullMovieDTO> ResponseFullMovie
        {
            get { return _responseFullMovie; }
            set
            {
                if (_responseFullMovie != value)
                {
                    _responseFullMovie = value;
                    OnPropertyChanaged(nameof(ResponseFullMovie));
                }
            }
        }

        public APIResponseSingle<CommentDTO> ResponseComment
        {
            get { return _responseComment; }
            set
            {
                if (_responseComment != value)
                {
                    _responseComment = value;
                    OnPropertyChanaged(nameof(ResponseComment));
                }
            }
        }

        public double IndexScrollViewerActor
        {
            get { return _indexScrollViewerActor; }
            set
            {
                if (_indexScrollViewerActor != value)
                {
                    _indexScrollViewerActor = value;
                    OnPropertyChanaged(nameof(IndexScrollViewerActor));
                }
            }
        }

        public bool IsInsertComment
        {
            get { return _isInsertComment; }
            set
            {
                if (_isInsertComment != value)
                {
                    _isInsertComment = value;
                    OnPropertyChanaged(nameof(IsInsertComment));
                }
            }
        }

        public bool IsLoadLightActors
        {
            get { return _isLoadLightActors; }
            set
            {
                if (_isLoadLightActors != value)
                {
                    _isLoadLightActors = value;
                    OnPropertyChanaged(nameof(IsLoadLightActors));
                }
            }
        }

        public bool IsLoadComments
        {
            get { return _isLoadComments; }
            set
            {
                if (_isLoadComments != value)
                {
                    _isLoadComments = value;
                    OnPropertyChanaged(nameof(IsLoadComments));
                }
            }
        }

        public int CurrentAction
        {
            get { return _currentAction; }
            set
            {
                if (_currentAction != value)
                {
                    _currentAction = value;
                    OnPropertyChanaged(nameof(CurrentAction));
                }
            }
        }
        #endregion

        #region BUILDERS
        public FullMovieViewModel(FullMovieView fullMovieView, int idMovie)
        {
            IdMovie = idMovie;
            FullMovieView = fullMovieView;
            IndexScrollViewerActor = 0;
            IsInsertComment = false;
            InsertCommentFullMovieCommand = new InsertCommentFullMovieCommand(this);
            ModifyCommentFullMovieCommand = new ModifyCommentFullMovieCommand(this);
            DeleteCommentFullMovieCommand = new DeleteCommentFullMovieCommand(this);
            InvalidateCommentFullMovieCommand = new InvalidateCommentFullMovieCommand(this);
            ValidateCommentFullMovieCommand = new ValidateCommentFullMovieCommand(this);
            SaveModifyCommentFullMovieCommand = new SaveModifyCommentFullMovieCommand(this);
            NavigationPreviousScrollViewCommand = new NavigationPreviousScrollViewCommand(this);
            NavigationNextScrollViewCommand = new NavigationNextScrollViewCommand(this);
            NavigationFirstPageActorCommand = new NavigationFirstPageActorCommand(this);
            NavigationLastPageActorCommand = new NavigationLastPageActorCommand(this);
            NavigationNextPageActorCommand = new NavigationNextPageActorCommand(this);
            NavigationPreviousPageActorCommand = new NavigationPreviousPageActorCommand(this);
            NavigationFirstPageCommentCommand = new NavigationFirstPageCommentCommand(this);
            NavigationLastPageCommentCommand = new NavigationLastPageCommentCommand(this);
            NavigationNextPageCommentCommand = new NavigationNextPageCommentCommand(this);
            NavigationPreviousPageCommentCommand = new NavigationPreviousPageCommentCommand(this);
            CloseFullMovieCommand = new CloseFullMovieCommand(this);
            LoadMovie();
        }
        #endregion

        #region METHODS
        public void ScrollViewerActorLeft(ScrollViewer scrollViewer)
        {
            IndexScrollViewerActor -= 1;
            if (IndexScrollViewerActor <= 0)
                IndexScrollViewerActor = 0;
            scrollViewer.ScrollToHorizontalOffset(IndexScrollViewerActor);
        }

        public void ScrollViewerActorRight(ScrollViewer scrollViewer)
        {
            IndexScrollViewerActor += 1;
            if (IndexScrollViewerActor >= scrollViewer.ScrollableWidth)
                IndexScrollViewerActor = scrollViewer.ScrollableWidth;
            scrollViewer.ScrollToHorizontalOffset(IndexScrollViewerActor);
        }

        public async Task FirstPageLightActors()
        {
            CurrentAction = Utils.Constant.METHOD_FIRST_PAGE_LIGHT_ACTORS;
            IsLoadLightActors = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameActor, 1);
            FullMovieActors.Clear();
            ResponseLightActors = await WebAPIManager.GetListLightActorsFromUrlAsync(PreviousResponseLightActors.FirstPage);
            if (ResponseLightActors.Succeeded)
            {
                await Utils.Utils.LightActorDTOsToLightActorModels(FullMovieActors, ResponseLightActors.Datas.ToList());
                PreviousResponseLightActors = ResponseLightActors;
                IndexScrollViewerActor = 0;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(FullMovieView.FrameActor);
                IsLoadLightActors = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameActor, 2, null, this);
        }

        public async Task LastPageLightActors()
        {
            CurrentAction = Utils.Constant.METHOD_LAST_PAGE_LIGHT_ACTORS;
            IsLoadLightActors = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameActor, 1);
            FullMovieActors.Clear();
            ResponseLightActors = await WebAPIManager.GetListLightActorsFromUrlAsync(PreviousResponseLightActors.LastPage);
            if (ResponseLightActors.Succeeded)
            {
                await Utils.Utils.LightActorDTOsToLightActorModels(FullMovieActors, ResponseLightActors.Datas.ToList());
                PreviousResponseLightActors = ResponseLightActors;
                IndexScrollViewerActor = 0;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(FullMovieView.FrameActor);
                IsLoadLightActors = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameActor, 2, null, this);
        }

        public async Task NextPageLightActors()
        {
            CurrentAction = Utils.Constant.METHOD_NEXT_PAGE_LIGHT_ACTORS;
            IsLoadLightActors = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameActor, 1);
            FullMovieActors.Clear();
            ResponseLightActors = await WebAPIManager.GetListLightActorsFromUrlAsync(PreviousResponseLightActors.NextPage);
            if (ResponseLightActors.Succeeded)
            {
                await Utils.Utils.LightActorDTOsToLightActorModels(FullMovieActors, ResponseLightActors.Datas.ToList());
                PreviousResponseLightActors = ResponseLightActors;
                IndexScrollViewerActor = 0;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(FullMovieView.FrameActor);
                IsLoadLightActors = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameActor, 2, null, this);
        }

        public async Task PreviousPageLightActors()
        {
            CurrentAction = Utils.Constant.METHOD_PREVIOUS_PAGE_LIGHT_ACTORS;
            IsLoadLightActors = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameActor, 1);
            FullMovieActors.Clear();
            ResponseLightActors = await WebAPIManager.GetListLightActorsFromUrlAsync(PreviousResponseLightActors.PreviousPage);
            if (ResponseLightActors.Succeeded)
            {
                await Utils.Utils.LightActorDTOsToLightActorModels(FullMovieActors, ResponseLightActors.Datas.ToList());
                PreviousResponseLightActors = ResponseLightActors;
                IndexScrollViewerActor = 0;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(FullMovieView.FrameActor);
                IsLoadLightActors = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameActor, 2, null, this);
        }

        public async Task FirstPageComments()
        {
            CurrentAction = Utils.Constant.METHOD_FIRST_PAGE_COMMENTS;
            IsLoadComments = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameComment, 1);
            FullMovieComments.Clear();
            ResponseComments = await WebAPIManager.GetListCommentsFromUrlAsync(PreviousResponseComments.FirstPage);
            if (ResponseComments.Succeeded)
            {
                await Task.Delay(2000);
                await Utils.Utils.CommentDTOsToCommentModels(FullMovieComments, ResponseComments.Datas.ToList());
                PreviousResponseComments = ResponseComments;
                Utils.Utils.CollapsedFrame(FullMovieView.FrameComment);
                IsLoadComments = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameComment, 2, null, this);
        }

        public async Task LastPageComments()
        {
            CurrentAction = Utils.Constant.METHOD_LAST_PAGE_COMMENTS;
            IsLoadComments = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameComment, 1);
            FullMovieComments.Clear();
            ResponseComments = await WebAPIManager.GetListCommentsFromUrlAsync(PreviousResponseComments.LastPage);
            if (ResponseComments.Succeeded)
            {
                await Task.Delay(2000);
                await Utils.Utils.CommentDTOsToCommentModels(FullMovieComments, ResponseComments.Datas.ToList());
                PreviousResponseComments = ResponseComments;
                Utils.Utils.CollapsedFrame(FullMovieView.FrameComment);
                IsLoadComments = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameComment, 2, null, this);
        }

        public async Task NextPageComments()
        {
            CurrentAction = Utils.Constant.METHOD_NEXT_PAGE_COMMENTS;
            IsLoadComments = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameComment, 1);
            FullMovieComments.Clear();
            ResponseComments = await WebAPIManager.GetListCommentsFromUrlAsync(PreviousResponseComments.NextPage);
            if (ResponseComments.Succeeded)
            {
                await Task.Delay(2000);
                await Utils.Utils.CommentDTOsToCommentModels(FullMovieComments, ResponseComments.Datas.ToList());
                PreviousResponseComments = ResponseComments;
                Utils.Utils.CollapsedFrame(FullMovieView.FrameComment);
                IsLoadComments = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameComment, 2, null, this);
        }

        public async Task PreviousPageComments()
        {
            CurrentAction = Utils.Constant.METHOD_PREVIOUS_PAGE_COMMENTS;
            IsLoadComments = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameComment, 1);
            FullMovieComments.Clear();
            ResponseComments = await WebAPIManager.GetListCommentsFromUrlAsync(PreviousResponseComments.PreviousPage);
            if (ResponseComments.Succeeded)
            {
                await Task.Delay(2000);
                await Utils.Utils.CommentDTOsToCommentModels(FullMovieComments, ResponseComments.Datas.ToList());
                PreviousResponseComments = ResponseComments;
                Utils.Utils.CollapsedFrame(FullMovieView.FrameComment);
                IsLoadComments = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameComment, 2, null, this);
        }

        public async Task LoadMovie()
        {
            CurrentAction = Utils.Constant.METHOD_LOAD_MOVIE;
            Utils.Utils.DisplayLoading(FullMovieView.Frame, 3);
            ResponseFullMovie = await WebAPIManager.GetFullMovieDetailsByIdMovieAsync(IdMovie);
            if (ResponseFullMovie.Succeeded)
            {
                await Task.Run(async () =>
                {
                    byte[] poster = await Task.Run(() =>
                    {
                        return DownloadUtils.DownloadImage(Utils.Constant.URL_IMAGE_THEMOVIEDB + ResponseFullMovie.Data.Poster);
                    });
                    byte[] logo = await Task.Run(() =>
                    {
                        return DownloadUtils.DownloadImage(Utils.Constant.URL_IMAGE_THEMOVIEDB + ResponseFullMovie.Data.Logo);
                    });
                    byte[] backdrop = await Task.Run(() =>
                    {
                        return Utils.Utils.DownloadBackdropMovie(ResponseFullMovie.Data.Backdrop);
                    });
                    Application.Current.Dispatcher.Invoke((Action)(delegate
                    {
                        FullMovie = new FullMovieModel(ResponseFullMovie.Data, poster, logo, backdrop);
                    }));
                });
                PreviousResponseFullMovie = ResponseFullMovie;
                FullMovieView.Title = FullMovie.Title;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(FullMovieView.Frame);
                LoadLightActors();
                LoadComments();
            }
            else
                Utils.Utils.DisplayError(FullMovieView.Frame, 3, null, this);
        }

        public async Task LoadLightActors()
        {
            CurrentAction = Utils.Constant.METHOD_LOAD_LIGHT_ACTORS;
            IsLoadLightActors = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameActor, 1);
            FullMovieActors.Clear();
            ResponseLightActors = await WebAPIManager.GetListActorsByIdMovieAsync(IdMovie, 1, Utils.Constant.PAGE_COUNT_LIGHT_ACTORS);
            if (ResponseLightActors.Succeeded)
            {
                await Utils.Utils.LightActorDTOsToLightActorModels(FullMovieActors, ResponseLightActors.Datas.ToList());
                PreviousResponseLightActors = ResponseLightActors;
                IndexScrollViewerActor = 0;
                await Task.Delay(2000);
                Utils.Utils.CollapsedFrame(FullMovieView.FrameActor);
                IsLoadLightActors = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameActor, 1, null, this);
        }

        public async Task LoadComments(int pageNumber = 1)
        {
            CurrentAction = Utils.Constant.METHOD_LOAD_COMMENTS;
            IsLoadComments = true;
            Utils.Utils.DisplayLoading(FullMovieView.FrameComment, 1);
            FullMovieComments.Clear();
            ResponseComments = await WebAPIManager.GetListCommentsByIdMovieAsync(IdMovie, pageNumber, Utils.Constant.PAGE_COUNT_COMMENTS, true);
            if (ResponseComments.Succeeded)
            {
                await Task.Delay(2000);
                await Utils.Utils.CommentDTOsToCommentModels(FullMovieComments, ResponseComments.Datas.ToList());  
                PreviousResponseComments = ResponseComments;
                Utils.Utils.CollapsedFrame(FullMovieView.FrameComment);
                IsLoadComments = false;
            }
            else
                Utils.Utils.DisplayError(FullMovieView.FrameComment, 1, null, this);
        }

        public async Task InsertComment()
        {
            string message = string.Empty;
            IsInsertComment = true;
            CommentDTO commentDTO = new CommentDTO(DateTime.Now, FullMovieView.RateNewCommentRB.Value + 1, FullMovieView.ContentNewCommentTBX.Text, FullMovieView.UsernameNewCommentTBX.Text, false);
            ResponseComment = await WebAPIManager.InsertCommentOnMovieIdAsync(FullMovie.Id, commentDTO);
            if (ResponseComment.Succeeded)
            {
                message = FullMovieView.UsernameNewCommentTBX.Text + "’s comment added !";
                FullMovieView.RateNewCommentRB.Value = 0;
                FullMovieView.ContentNewCommentTBX.Text = string.Empty;
                FullMovieView.UsernameNewCommentTBX.Text = string.Empty;
                LoadComments();
            }
            else
                message = "Error adding" + FullMovieView.UsernameNewCommentTBX.Text + "'s comment ! Please try again.";
            IsInsertComment = false;
            FullMovieView.Notification.MessageQueue.Enqueue(message);
        }

        public void ModifyComment(int idComment)
        {
            bool isModifyComment = false;
            if(FullMovieComments.Any(c => c.Id == idComment))
            {
                CommentModel commentModel = FullMovieComments.FirstOrDefault(c => c.Id == idComment);
                if(commentModel.Id != -1)
                {
                    commentModel.Modify = true;
                    isModifyComment = true;
                }
            }
            if(!isModifyComment)
                FullMovieView.Notification.MessageQueue.Enqueue("Error while editing the comment ! Please try again.");
        }

        public async Task SaveModifyComment(int idComment)
        {
            CommentModel commentModel = new CommentModel();
            string message = string.Empty;
            bool isSaveModifyComment = false;
            commentModel = FullMovieComments.FirstOrDefault(c => c.Id == idComment);
            if (commentModel.Id != -1)
            {
                commentModel.Manipulation = true;
                CommentDTO commentDTO = new CommentDTO(commentModel.Id, commentModel.Date, (int)Math.Round(commentModel.Rate), commentModel.Content, commentModel.Username, commentModel.Valid);
                ResponseComment = await WebAPIManager.ModifyCommentByIdCommentAsync(idComment, commentDTO);
                if (ResponseComment.Succeeded)
                {
                    if(ResponseComment.Data.Date == commentDTO.Date)
                    {
                        message = "No change to the comment was detected !";
                    }
                    else
                    {
                        int indexCommentModel = FullMovieComments.IndexOf(commentModel);
                        FullMovieComments.RemoveAt(indexCommentModel);
                        FullMovieComments.Insert(indexCommentModel, new CommentModel(ResponseComment.Data));
                        FullMovie.Rating = Utils.Utils.GetAverageRateCommentModels(FullMovieComments.ToList());
                        message = commentModel.Username + "’s comment edited !";
                    }
                    isSaveModifyComment = true;
                    commentModel.Manipulation = false;
                    commentModel.Modify = false;
                }
            }
            if (!isSaveModifyComment)
            {
                if (commentModel != null && commentModel.Id != -1)
                {
                    commentModel.Manipulation = false;
                    commentModel.Modify = false;
                } 
                message = "Error while saving the comment edited ! Please try again.";
            }
            FullMovieView.Notification.MessageQueue.Enqueue(message);
        }

        public async Task DeleteComment(int idComment)
        {
            CommentModel commentModel = new CommentModel();
            string message = string.Empty;
            bool isDeleteComment = false;
            commentModel = FullMovieComments.FirstOrDefault(c => c.Id == idComment);
            if (commentModel.Id != -1)
            {
                commentModel.Manipulation = true;
                ResponseComment = await WebAPIManager.DeleteCommentByIdCommentAsync(idComment);
                if(ResponseComment.Succeeded)
                {
                    LoadComments(PreviousResponseComments.PageNumber);
                    FullMovie.Rating = Utils.Utils.GetAverageRateCommentModels(FullMovieComments.ToList());
                    message = commentModel.Username + "’s comment deleted !";
                }
            }
            if (!isDeleteComment)
            {
                if (commentModel != null && commentModel.Id != -1)
                    commentModel.Manipulation = false;
                message = "Error while deleting the comment ! Please try again.";
            }
            FullMovieView.Notification.MessageQueue.Enqueue(message);
        }

        public async Task InvalidateOrValidateComment(int idComment, bool isValid)
        {
            CommentModel commentModel = new CommentModel();
            string message = string.Empty;
            bool isInvalidateOrValidateComment = false;
            commentModel = FullMovieComments.FirstOrDefault(c => c.Id == idComment);
            if (commentModel.Id != -1)
            {
                commentModel.Manipulation = true;
                ResponseComment = await WebAPIManager.InvalidateOrValidateCommentByIdCommentAsync(idComment, isValid);
                if (ResponseComment.Succeeded)
                {
                    commentModel.Valid = isValid;
                    if (isValid)
                        message = commentModel.Username + "’s comment validated !";
                    else
                        message = commentModel.Username + "’s comment invalidated !";
                    FullMovie.Rating = Utils.Utils.GetAverageRateCommentModels(FullMovieComments.ToList());
                    isInvalidateOrValidateComment = true;
                    commentModel.Manipulation = false;
                }
            }
            if (!isInvalidateOrValidateComment)
            {
                if (commentModel != null && commentModel.Id != -1)
                    commentModel.Manipulation = false;
                if (isValid)
                    message = "Error while validating the comment ! Please try again.";
                else
                    message = "Error while invalidating the comment ! Please try again.";
            }
            FullMovieView.Notification.MessageQueue.Enqueue(message);
        }

        public void Close()
        {
            FullMovieView.Close();
        }
        #endregion

        #region NOTIFYPROPERTYCHANGED
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanaged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
