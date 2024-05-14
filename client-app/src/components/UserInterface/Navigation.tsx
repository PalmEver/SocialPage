import React from "react";
import { Link } from "react-router-dom";
import logo from "../../Assets/logo.png";
import profile from "../../Assets/profile.png";

const Navigation = (props: {
  name: string;
  setName: (name: string) => void;
}) => {
  const logout = async () => {
    await fetch("http://localhost:5000/api/Auth/logout", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      credentials: "include",
    });

    props.setName("");
  };
  let menu;

  if (props.name === "") {
    menu = (
      <ul className="navbar-nav me-auto mb-2 mb-md-0">
        <li className="nav-item active">
          <Link to="/login" className="nav-link">
            Login
          </Link>
        </li>
        <li className="nav-item active">
          <Link to="/register" className="nav-link">
            Register
          </Link>
        </li>
      </ul>
    );
  } else {
    menu = (
      <div>
        <Link to="/profile">
          <img
            src={profile}
            width="30"
            height="30"
            className="d-inline-block align-top"
            alt="React Bootstrap logo"
          />
        </Link>
        <ul className="navbar-nav me-auto mb-2 mb-md-0">
          <li className="nav-item active">
            <Link to="/users" className="nav-link">
              UsersPage
            </Link>
          </li>
          <li className="nav-item active">
            <Link to="/login" className="nav-link" onClick={logout}>
              Logout
            </Link>
          </li>
        </ul>
      </div>
    );
  }

  return (
    <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
      <div className="container-fluid">
        <Link to="/">
          <img
            src={logo}
            width="30"
            height="30"
            className="d-inline-block align-top"
            alt="React Bootstrap logo"
          />
        </Link>
        <div>{menu}</div>
      </div>
    </nav>
  );
};

export default Navigation;
