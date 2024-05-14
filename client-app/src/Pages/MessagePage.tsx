import axios from "axios";
import React, { SyntheticEvent, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetUser } from "../components/Functions/GetUser";
import { Message } from "../components/models/message";

const MessagePage = () => {
  const [allMessages, setAllMessages] = useState<Message[]>([]);

  const params = useParams();
  const messageId = params.followId;

  const user = GetUser().user;
  const userId = user.id;
  const name = user.name;

  const [message, setMessage] = useState("");

  useEffect(() => {
    if (userId && messageId) {
      UpdateResponseData();
    }
  }, [userId]);

  const UpdateResponseData = () => {
    axios
      .get(`http://localhost:5000/api/Message/${userId}/${messageId}`)
      .then((response) => setAllMessages(response.data));
  };

  const Send = async (e: SyntheticEvent) => {
    e.preventDefault();
    if (userId == null) {
      alert("You are not logged in");
    } else {
      await axios.post("http://localhost:5000/api/Message", {
        message,
        messageId,
        name,
        userId,
      });
    }
    axios
      .get(`http://localhost:5000/api/Message/${userId}/${messageId}`)
      .then((response) => setAllMessages(response.data));
  };

  return (
    <div className="wrapper">
      <div className="card text-center">
        <div className="card-header">
          <h1>Message user</h1>
        </div>
        <>
          {allMessages &&
            allMessages.map((message) => (
              <>
                <div className="card-container">
                  <div className="card-body">
                    <h5 className="card-title">{message.name} wrote:</h5>
                    <h6 className="card-text">{message.message}</h6>
                    <p className="card-text">Sent: {message.date}</p>
                  </div>
                  <div className="card-footer text-muted"></div>
                </div>
              </>
            ))}
        </>
        <div className="wrapper">
          <form className="form-signin" onSubmit={Send}>
            <input
              className="form-control"
              placeholder="..."
              required
              onChange={(e) => setMessage(e.target.value)}
            />
            <button className="w-100 btn btn-lg btn-primary" type="submit">
              Send
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default MessagePage;
