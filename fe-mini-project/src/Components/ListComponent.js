import React, { useState, useEffect } from 'react'
import bookService from '../Services/BookService'
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import cellEditFactory from 'react-bootstrap-table2-editor';
import filterFactory, { textFilter } from 'react-bootstrap-table2-filter';
import { Link } from 'react-router-dom';
import { ShowErrorAlert, ShowSuccessAlert } from '../Utils/Toast';

const BookList = () => {
    const [books, setBooks] = useState([]);
    useEffect(() => {
        getBooks();
    }, []);

    const state = {
        columns: [{
            dataField: 'isbn',
            text: 'ISBN',
            filter: textFilter()
        },
        {
            dataField: 'name',
            text: 'Name',
            sort: true,
        },
        {
            dataField: 'authors',
            text: 'Authors',
            sort: true,
            formatter: (cellContent, row) => {
                return (
                    <div>
                        {row.authors.map(author => (
                            <div key={author.id}>{author.name}</div>
                        ))}
                    </div>
                );
            }
        },
        {
            dataField: 'price',
            text: 'Price',
            sort: true,
            formatter: (cell, row) => `${cell} €`
        },
        {
            dataField: 'active',
            text: 'Active',
            editable: false
        },
        {
            dataField: "remove",
            text: "Action",
            editable: false,
            formatter: (cellContent, row) => {
                return (
                    <button
                        className="btn btn-danger btn-xs"
                        onClick={() => handleDelete(row.isbn)}
                    >
                        Delete
                    </button>
                );
            },
        },]
    }

    const getBooks = async () => {
        var response = await bookService.getAllBooks();
        setBooks(response.obj);
        if (response.success === false) {
            ShowErrorAlert(response.message);
            return;
        }
    };

    const handleDelete = async (isbn) => {
        var response = await bookService.deleteBook(isbn);
        getBooks();
        if (response.success === false) {
            ShowErrorAlert(response.message);
            return;
        }
        ShowSuccessAlert(response.message);
    };

    const handleEdit = async (updatedBook) => {
        var response = await bookService.updateBook(updatedBook);
        getBooks();
        if (response.success === false) {
            ShowErrorAlert(response.message);
            return;
        }
        ShowSuccessAlert(response.message);
    };

    return (
        <div className="container">
            <h2 className="my-4">Book List</h2>
            <ul className="list-group">
                <BootstrapTable
                    striped
                    hover
                    keyField='isbn'
                    data={books}
                    columns={state.columns}
                    pagination={paginationFactory()}
                    cellEdit={cellEditFactory({
                        mode: 'click',
                        afterSaveCell: async (oldValue, newValue, row, column) => {
                            const updatedBook = { isbn: row.isbn, name: row.name, author: row.authorIds, price: row.price, acive: row.active };
                            handleEdit(updatedBook);
                        }
                    })}
                    filter={filterFactory()}
                    filterPosition="top"
                ></BootstrapTable>
            </ul>
        </div>
    );
};
export default BookList;