using DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Utils.APIUtils;
using Utils.APIUtils.Models;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FullMovieViewModel
    {
        public FullMovieModel _movie;
        public FullMovieViewModel(FullMovieDTO fullMovieDTO)
        {
            _movie = new FullMovieModel(fullMovieDTO);
        }
        public async Task AjouterCommentaire(int id, string Content, int Rate, string username)
        {
            CommentDTO commentDTO = new CommentDTO(DateTime.Now, Rate, Content, username);
            APIResponseSingle<CommentDTO> response = await WebAPIManager.InsertCommentOnMovieIdAsync(id, commentDTO);
        }

    }
}
