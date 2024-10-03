import axios from 'axios';


const baseURL = "http://localhost:5151/Author";
const authorService = {
    getAllAuthors: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    getAuthorById: async (id) => {
        const response = await axios.get(`${baseURL}/${id}`);
        return response.data;
    },
    addAuthor: async (author) => {
        const response = await axios.post(baseURL,author);
        return response.data;
    },
    deleteAuthor: async (id) => {
        const response = await axios.delete(`${baseURL}/${id}`);
        console.log(response.data);
        return response.data;
    },
    updateAuthor: async (author) => {
        const response = await axios.put(baseURL,author);
        return response.data;
    }
};

export default authorService