import axios from "axios";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Follow } from "../components/models/follow";
import "../CSS/ProfilePage.css";

const UserProfile = () => {
  const [userPosts, setUserPosts] = useState<Follow[]>([]);

  const params = useParams();
  const userId = params.followId;

  useEffect(() => {
    if (userId) {
      UpdateResponseData();
    }
  }, [userId]);

  const UpdateResponseData = () => {
    axios
      .get(`http://localhost:5000/api/Posts/user/${userId}`)
      .then((response) => setUserPosts(response.data));
  };

  const UserPostRender = () => {
    return (
      <>
        {userPosts &&
          userPosts.map((posts) => (
            <>
              <div className="card-container">
                <div className="card">
                  <div className="card-body">
                    <h1>{posts.user}</h1>
                    <h2>{posts.posts}</h2>
                    <p>{posts.date}</p>
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
          {/* <h3>{userPosts.name}</h3>
          <p>{userPosts.email}</p> */}
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

export default UserProfile;
