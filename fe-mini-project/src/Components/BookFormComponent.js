import React, { useState, useEffect } from 'react';
import { Multiselect } from "multiselect-react-dropdown";
import bookService from '../Services/BookService';
import authorService from '../Services/AuthorService';
import { ShowErrorAlert, ShowSuccessAlert } from '../Utils/Toast';

const AddBook = () => {
    const [isbn, setISBN] = useState('');
    const [name, setName] = useState('');
    const [authors, setAuthors] = useState([]);
    const [authorIdsArray, setAuthorIdsArray] = useState([]);
    const [price, setPrice] = useState('');
    const [active, setActive] = useState(true);
    useEffect(() => {
        getAuthors();
    }, []);

    const getAuthors = async () => {

        const response = await authorService.getAllAuthors();
        setAuthors(response.obj);
        if (response.success === false) {
            ShowErrorAlert(response.message);
            return;
        }
    };

    const handleChange = (selectedId) => {
        setAuthorIdsArray(selectedId);
    }

    const handleBookSubmit = async (event) => {
        event.preventDefault();
        const authorIds = [];
        authorIdsArray.forEach(author => {
            authorIds.push(author.id);
        });
        const newBook = { isbn, name, price: parseFloat(price), active, authorIds };
        var response = await bookService.addBook(newBook);
        if (response.success === false) {
            ShowErrorAlert(response.message);
            return;
        }
        ShowSuccessAlert(response.message);
        setAuthorIdsArray([]);
        setISBN('');
        setName('');
        setPrice('');

    };
    return (
        <div className="container">
            <h2 className="my-4">Add Book</h2>
            <form onSubmit={handleBookSubmit}>
                <div className="mb-3">
                    <label className="form-label">ISBN:</label>
                    <input type="text" className="form-control" id="bookISBN" value={isbn} onChange={e => setISBN(e.target.value)} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Name:</label>
                    <input type="text" className="form-control" id="bookName" value={name} onChange={e => setName(e.target.value)} required />
                </div>
                <div className="mb-3">
                    <label className="form-label">Author:</label>
                    <Multiselect
                        placeholder="Select authors"
                        options={authors}
                        selectedValues={authorIdsArray}
                        onSelect={handleChange}
                        displayValue="name"
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label">Price:</label>
                    <input type="number" className="form-control" id="bookPrice" value={price} onChange={e => setPrice(e.target.value)} required />
                </div>
                <button type="submit" className="btn btn-primary">Add Book</button>
            </form>
        </div>
    );
};

export default AddBook;