import axios from "axios";
import React from "react";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Users } from "../models/user";
import FollowButton from "../UserInterface/FollowButton";

export const UserList = () => {
  const [users, setUsers] = useState<Users[]>([]);

  useEffect(() => {
    axios
      .get("http://localhost:5000/api/User", { withCredentials: true })
      .then((response) => setUsers(response.data));
  }, []);

  let followId = 0;

  return (
    <>
      {users &&
        users.map((user) => (
          <>
            <div className="card-container">
              <div className="card-body">
                <h5 className="card-title">{user.name}</h5>
                <p>{(followId = user.id)}</p>
                <p className="card-text">{user.email}</p>
                <FollowButton setFollowId={followId} />
                <Link
                  to={`/message/${followId}`}
                  className="btn btn-primary space"
                >
                  Message
                </Link>
                <Link
                  to={`/userProfile/${followId}`}
                  className="btn btn-primary space"
                >
                  Profile
                </Link>
              </div>
              <div className="card-footer text-muted"></div>
            </div>
          </>
        ))}
    </>
  );
};
export default UserList;
