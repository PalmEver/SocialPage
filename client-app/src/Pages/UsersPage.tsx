import React, { SyntheticEvent, useState } from "react";
import UserList from "../components/Functions/UserList";

const UsersPage = () => {
  return (
    <div className="wrapper">
      <div className="card text-center">
        <div className="card-header">
          <h1>Registered Users</h1>
        </div>
        <UserList />
      </div>
    </div>
  );
};

export default UsersPage;
