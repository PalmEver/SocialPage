import axios from "axios";
import React, { useEffect, useState } from "react";
import { GetUser } from "../components/Functions/GetUser";
import { Follow } from "../components/models/follow";
import "../CSS/ProfilePage.css";

const Profile = () => {
  const user = GetUser().user;
  const [posts, setPosts] = useState<Follow[]>([]);

  let userId = user.id;

  useEffect(() => {
    if (userId) {
      UpdateResponseData();
    }
  }, [userId]);

  const UpdateResponseData = () => {
    axios
      .get(`http://localhost:5000/api/Posts/user/${userId}`)
      .then((response) => setPosts(response.data));
  };
  const UserPostRender = () => {
    return (
      <>
        {posts &&
          posts.map((post) => (
            <>
              <div className="card-container">
                <div className="card">
                  <div className="card-body">
                    <h1>{post.user}</h1>
                    <h2>{post.posts}</h2>
                    <p>{post.date}</p>
                  </div>
                </div>
              </div>
            </>
          ))}
      </>
    );
  };

  let profilePage;

  if (userId == null) {
    profilePage = (
      <div>
        <div className="card-header">
          <h1>You are not logged in</h1>
        </div>
      </div>
    );
  } else {
    profilePage = (
      <div>
        <div className="jumbo"></div>
        <div className="container icons">
          <div className="big-icon"></div>
        </div>
        <div className="details">
          <h3>{user.name}</h3>
          <p>{user.email}</p>
        </div>
        <div className="container bio">
          <div className="title">
            <h6>Biography</h6>
          </div>
          <div>
            <p>
              Lorem ipsum dolor sit amet, consectetur adipisicing elit. Porro
              officiis fugit hic vel voluptates perferendis aut quibusdam sit
              omnis unde aspernatur quae repellat blanditiis autem, a libero
              asperiores neque illum aliquid est tempore. Eveniet velit
              voluptate amet facere, repellendus aperiam, cumque est ipsam.
              Asperiores expedita iusto, inventore sit suscipit nihil
              repudiandae? Laboriosam cum maxime dolorem neque, in veniam
              expedita ad. Hic fugit necessitatibus blanditiis, optio
              dignissimos molestiae nam, numquam odio.
            </p>
          </div>
          <UserPostRender />
        </div>
      </div>
    );
  }

  return <>{profilePage}</>;
};

export default Profile;
