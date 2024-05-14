import React, { SyntheticEvent, useState } from "react";
import { Navigate } from "react-router-dom";
import Waves from "../components/UserExperience/Waves";
import "../CSS/LoginRegister.css";

const Register = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [redirect, setRedirect] = useState(false);

  const submit = async (e: SyntheticEvent) => {
    e.preventDefault();

    await fetch("http://localhost:5000/api/Auth/register", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        name,
        email,
        password,
      }),
    });

    setRedirect(true);
  };

  if (redirect) {
    return <Navigate to="/login" />;
  }

  return (
    <>
      <div className="wrapper">
        <form className="form-signin" onSubmit={submit}>
          <h1 className="h3 mb-3 fw-normal">Please register</h1>
          <input
            className="form-control"
            placeholder="Name"
            required
            onChange={(e) => setName(e.target.value)}
          />
          <input
            type="email"
            className="form-control"
            placeholder="Email address"
            required
            onChange={(e) => setEmail(e.target.value)}
          />
          <input
            type="password"
            className="form-control"
            placeholder="Password"
            required
            onChange={(e) => setPassword(e.target.value)}
          />
          <button className="w-100 btn btn-lg btn-primary" type="submit">
            Submit
          </button>
        </form>
      </div>
      <Waves />
    </>
  );
};

export default Register;
