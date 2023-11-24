using System.Collections.Generic;
using lab3b.Models;


namespace lab3b.Models;

public interface IAlbumService
{
    int Add(Album albumViewModel);
    void Update(Album albumViewModel);
    void Delete(int id);
    List<Album> FindAll();
    Album FindById(int id);
}