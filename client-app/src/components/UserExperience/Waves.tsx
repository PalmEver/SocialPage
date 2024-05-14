import React from "react";
import "../../CSS/Waves.css";

const Waves = () => {
  return (
    <div className="bottom">
      <div className="header">
        <div>
          <svg
            className="waves"
            xmlns="http://www.w3.org/2000/svg"
            xmlnsXlink="http://www.w3.org/1999/xlink"
            viewBox="0 24 150 28"
            preserveAspectRatio="none"
            shapeRendering="auto"
          >
            <defs>
              <path
                id="gentle-wave"
                d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z"
              />
            </defs>
            <g className="parallax">
              <use
                xlinkHref="#gentle-wave"
                x="48"
                y="0"
                fill="rgb(63, 76, 119, 0.7)"
              />
              <use
                xlinkHref="#gentle-wave"
                x="48"
                y="3"
                fill="rgb(55, 65, 98, 0.5)"
              />
              <use
                xlinkHref="#gentle-wave"
                x="48"
                y="5"
                fill="rgb(32, 38, 57, 0.3)"
              />
              <use
                xlinkHref="#gentle-wave"
                x="48"
                y="7"
                fill="rgb(63, 76, 119)"
              />
            </g>
          </svg>
        </div>
      </div>
      <div className="content flex">
        <h1>Social-Page</h1>
      </div>
    </div>
  );
};

export default Waves;
