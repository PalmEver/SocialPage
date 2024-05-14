import React from "react";
import CreatePost from "../components/Functions/CreatePost";
import { GetUser } from "../components/Functions/GetUser";
import Posts from "../components/Functions/Posts";

const Home = () => {
  const userName = GetUser().user.name;

  return (
    <div>
      <h3>{userName ? "Hi " + userName : "You are not logged in"}</h3>
      <CreatePost />
      <Posts />
    </div>
  );
};

export default Home;
