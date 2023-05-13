/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/

namespace AstarLibrary.Core
{
    public interface ICacheHandler
    {
        void Save<T>(string path, T obj);
        T Load<T>(string path);
        bool Exist(string path);
    }
}