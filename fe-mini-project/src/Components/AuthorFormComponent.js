import React, { useState } from 'react';
import authorService from '../Services/AuthorService';
import { ShowErrorAlert, ShowSuccessAlert } from '../Utils/Toast';


const AddAuthor = () => {
    const [name, setName] = useState('');
    const [active, setActive] = useState(true);

    const handleAuthorSubmit = async (event) => {
        event.preventDefault();
        const newAuthor = { name, active, bookIds: [] };
        var response = await authorService.addAuthor(newAuthor);
        if (response.success === false) {
            ShowErrorAlert(response.message);
            return;
        }
        ShowSuccessAlert(response.message);
        setName('');
    };

    return (
        <div className="container">
            <h2 className="my-4">Add Author</h2>
            <form onSubmit={handleAuthorSubmit}>
                <div className="mb-3">
                    <label className="form-label">Name:</label>
                    <input type="text" className="form-control" id="AuthorName" value={name} onChange={e => setName(e.target.value)} required />
                </div>
                <button type="submit" className="btn btn-primary">Add Author</button>
            </form>
        </div>
    );
};

export default AddAuthor;