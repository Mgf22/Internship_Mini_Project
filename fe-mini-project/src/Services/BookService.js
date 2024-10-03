import axios from 'axios';


const baseURL = "http://localhost:5151/Book";
const bookService = {
    getAllBooks: async () => {
        const response = await axios.get(baseURL);
        return response.data;
    },
    getBookByISBN: async (isbn) => {
        const response = await axios.get(`${baseURL}/${isbn}`);
        return response.data;
    },
    addBook: async (book) => {
        const response = await axios.post(baseURL,book);
        return response.data;
    },
    deleteBook: async (isbn) => {
        const response = await axios.delete(`${baseURL}/${isbn}`);
        console.log(response.data);
        return response.data;
    },
    updateBook: async (book) => {
        const response = await axios.put(baseURL,book);
        return response.data;
    },
    activateBook: async (isbn) => {
        const response = await axios.patch(baseURL + '/' +isbn);
        return response.data;
    }
};

export default bookService