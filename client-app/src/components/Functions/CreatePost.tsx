import axios from "axios";
import React, { SyntheticEvent, useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import agent from "../../API/agent";
import { Follow } from "../models/follow";
import { Post } from "../models/post";
import { GetUser } from "./GetUser";

const CreatePost = () => {
  const [description, setDescription] = useState("");
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

  const submit = async (e: SyntheticEvent) => {
    e.preventDefault();

    if (userId == null) {
      alert("You are not logged in");
    } else {
      await fetch("http://localhost:5000/api/posts", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        credentials: "include",
        body: JSON.stringify({
          description,
          userId,
        }),
      });
      axios
        .get(`http://localhost:5000/api/Posts/follow/` + userId, {
          withCredentials: true,
        })
        .then((response) => setFollowerPosts(response.data));
    }
  };
  return (
    <>
      <div className="wrapper">
        <form className="form-signin" onSubmit={submit}>
          <input
            className="form-control"
            placeholder="Post something"
            required
            onChange={(e) => setDescription(e.target.value)}
          />
          <button className="w-100 btn btn-lg btn-primary" type="submit">
            Submit
          </button>
        </form>
      </div>
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
    </>
  );
};

export default CreatePost;
