using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Mini_projeto_Book_Samsys.Helpers;
using Mini_projeto_Book_Samsys.Models.DTOs;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Repositories.Unit_of_work;
using Mini_projeto_Book_Samsys.Services;

namespace Mini_projeto_Author_Samsys.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageHelper<IEnumerable<Author>>> GetAllAuthors()
        {
            MessageHelper<IEnumerable<Author>> response = new();
            IEnumerable<Author> authors = await _unitOfWork.Authors.GetAll();
            if (authors.IsNullOrEmpty())
            {
                response.Success = true;
                response.Message = "List is empty";
                response.Obj = authors;
                return response;
            }
            response.Success = true;
            response.Message = "List retrieved with success";
            response.Obj = authors;
            return response;
        }

        public async Task<MessageHelper<Author>> GetAuthorById(int id)
        {
            MessageHelper<Author> response = new();
            Author author = await _unitOfWork.Authors.GetById(id);
            if (author is null)
            {
                response.Success = false;
                response.Message = "Author doesn't exist";
                response.Obj = author;
                return response;
            }
            response.Success = true;
            response.Message = "Author founded with success";
            response.Obj = author;
            return response;
        }

        public async Task<MessageHelper<Author>> AddAuthor(AuthorDTO authorDTO)
        {
            MessageHelper<Author> response = new();
            Author author = _mapper.Map<Author>(authorDTO);
            await _unitOfWork.Authors.Add(author);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Author created with success";
            response.Obj = author;
            return response;
        }

        public async Task<MessageHelper> DeleteAuthor(int id)
        {
            MessageHelper response = new();
            Author author = await _unitOfWork.Authors.GetById(id);
            if (author is null)
            {
                response.Success = false;
                response.Message = "Author doesn´t exist";
                return response;
            }
            bool task = author.DeleteAuthor();
            if (task == false)
            {
                response.Success = true;
                response.Message = "Author was already deleted";
                return response;
            }
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Author deleted with success";
            return response;
        }

        public async Task<MessageHelper<Author>> UpdateAuthor(int id,AuthorDTO authorDTO)
        {
            MessageHelper<Author> response = new();
            Author author = _mapper.Map<Author>(authorDTO);
            Author authorToChange = await _unitOfWork.Authors.GetById(id);
            if (authorToChange is null)
            {
                response.Success = false;
                response.Message = "Author doesn´t exist";
                response.Obj = authorToChange;

                return response;
            }
            authorToChange.Update(author);
            await _unitOfWork.Save();
            response.Success = true;
            response.Message = "Author updated with success";
            response.Obj = authorToChange;
            return response;
        }
    }
}
