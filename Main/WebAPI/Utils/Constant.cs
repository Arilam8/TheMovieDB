namespace WebAPI.Utils
{
    public class Constant
    {
        public const string URL_IMAGE_THEMOVIEDB = "https://image.tmdb.org/t/p/original";
        public const string WEBAPI_ADDRESS_IP = "https://127.0.0.1:5001/v1/";
        public const string ROUTE_GETACTORBYIDACTOR = "{idActor}";
        public const string ROUTE_GETLISTACTORSBYIDMOVIE = "{idMovie}&pageNumber={pageNumber}&pageCount={pageCount}";
        public const string ROUTE_GETFAVORITEACTORS = "FavoriteActors/pageNumber={pageNumber}&pageCount={pageCount}";
        public const string ROUTE_GETFULLMOVIEDETAILSBYIDMOVIE = "{idMovie}";
        public const string ROUTE_GETLISTFULLMOVIEORDERBYRELEASEDATE = "pageNumber={pageNumber}&pageCount={pageCount}";
        public const string ROUTE_FINDLISTMOVIEBYPARTIALMOVIETITLE = "title={title}&pageNumber={pageNumber}&pageCount={pageCount}";
        public const string ROUTE_FINDLISTMOVIEBYPARTIALACTORNAME = "name={name}&pageNumber={pageNumber}&pageCount={pageCount}";
        public const string ROUTE_GETCOMMENTBYIDCOMMENT = "{idComment}";
        public const string ROUTE_GETLISTCOMMENTSBYIDMOVIE = "{idMovie}&pageNumber={pageNumber}&pageCount={pageCount}&invalidComment={invalidComment}";
        public const string ROUTE_INSERTCOMMENTONMOVIEID = "{idMovie}";
        public const string ROUTE_DELETECOMMENTBYIDCOMMENT = "{idComment}";
        public const string ROUTE_MODIFYCOMMENTBYIDCOMMENT = "{idComment}";
        public const string ROUTE_INVALIDATEORVALIDATECOMMENTBYIDCOMMENT = "{idComment}";
    }
}
