import axios from "axios";
import React from "react";
import { useEffect, useState } from "react";
import { Follow } from "../models/follow";
import { GetUser } from "./GetUser";

export const Posts = () => {
  const [followerPosts, setFollowerPosts] = useState<Follow[]>([]);
  const userId = GetUser().user.id;

  useEffect(() => {
    if (userId) {
      UpdateResponseData();
    }
  }, [userId]);
  const UpdateResponseData = () => {
    axios
      .get(`http://localhost:5000/api/Posts/follow/` + userId, {
        withCredentials: true,
      })
      .then((response) => setFollowerPosts(response.data));
  };

  return (
    <>
      {followerPosts &&
        followerPosts.map((follower) => (
          <>
            <div className="card-container">
              <div className="card">
                <div className="card-body">
                  <h1>{follower.user}</h1>
                  <h2>{follower.posts}</h2>
                  <p>{follower.date}</p>
                </div>
              </div>
            </div>
          </>
        ))}
    </>
  );
};
export default Posts;
