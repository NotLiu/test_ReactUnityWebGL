import React, { Fragment } from "react";
import ReactDOM from "react-dom";
import "./index.css";
import Unity from "react-unity-webgl";
import { UnityContext } from "react-unity-webgl";
import reportWebVitals from "./reportWebVitals";

const unityContext = new UnityContext({
  loaderUrl: "build/public.loader.js",
  dataUrl: "build/public.data",
  frameworkUrl: "build/public.framework.js",
  codeUrl: "build/public.wasm",
});

function App() {
  return (
    <Fragment>
      <div className="App">
        <div id="unity">
          <Unity unityContext={unityContext} /> Hello World
        </div>
      </div>
    </Fragment>
  );
}

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById("unity-canvas")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
