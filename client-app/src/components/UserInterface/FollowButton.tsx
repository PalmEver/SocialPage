import axios from "axios";
import React from "react";
import { GetUser } from "../Functions/GetUser";

export const FollowButton = (props: { setFollowId: number }) => {
  const userId = GetUser().user.id;
  const followId = props.setFollowId;

  function follow() {
    if (userId == null) {
      alert("You are not logged in");
    } else {
      try {
        axios.post("http://localhost:5000/api/Follow", {
          followId,
          userId,
        });
      } catch (error) {
        alert("You already follow this user");
      }
    }
  }

  return (
    <>
      <button className="btn btn-primary space" onClick={follow}>
        Follow
      </button>
    </>
  );
};
export default FollowButton;
