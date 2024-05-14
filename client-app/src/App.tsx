import React, { useEffect, useState } from "react";
import "./App.css";
import Login from "./Pages/LoginPage";

import Register from "./Pages/Register";
import Home from "./Pages/HomePage";
import Navigation from "./components/UserInterface/Navigation";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { GetUser } from "./components/Functions/GetUser";
import Profile from "./Pages/ProfilePage";
import UsersPage from "./Pages/UsersPage";
import MessagePage from "./Pages/MessagePage";
import UserProfilePage from "./Pages/UserProfilePage";

function App() {
  const [name, setName] = useState("");

  useEffect(() => {
    (async () => {
      const response = await fetch(`http://localhost:5000/api/Auth/user`, {
        headers: { "Content-Type": "application/json" },
        credentials: "include",
      });

      const content = await response.json();

      setName(content.name);
    })();
  }, [setName]);

  return (
    <div className="App">
      <BrowserRouter>
        <Navigation name={name} setName={setName} />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login setName={setName} />} />
          <Route path="/register" element={<Register />} />
          <Route path="/profile" element={<Profile />} />
          <Route path="/users" element={<UsersPage />} />
          <Route path="/message/:followId" element={<MessagePage />} />
          <Route path="/userProfile/:followId" element={<UserProfilePage />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
