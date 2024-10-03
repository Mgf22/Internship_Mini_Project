import React, { useState } from 'react';
import './App.css';
import BookForm from './Components/BookFormComponent';
import AuthorForm from './Components/AuthorFormComponent';
import List from './Components/ListComponent';
import Layout from './Components/Layout';
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
  const [refresh, setRefresh] = useState(false);
  const handleAddedValue = () => {
    setRefresh(!refresh); // Toggle refresh state to trigger re-render
  };
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="/list" element={<List />} />
          <Route path="/addAuthor" element={<AuthorForm />} />
          <Route path="/addBook" element={<BookForm />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
