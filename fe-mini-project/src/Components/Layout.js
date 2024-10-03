import { Outlet, Link } from "react-router-dom";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { NavLink } from "react-router-dom";

const Layout = () => {
  return (
    <>
      <Navbar bg="dark" data-bs-theme="dark">
        <Container>
          <Navbar.Brand>Book Samsys</Navbar.Brand>
          <Nav>
            <Nav.Link href="/list">List</Nav.Link> {/*It was supposed to be to not href but link ain't working*/}
            <Nav.Link href="/addAuthor">Add Author</Nav.Link>
            <Nav.Link href="/addBook">Add Book</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
      <Outlet />
    </>
  )
};

export default Layout;