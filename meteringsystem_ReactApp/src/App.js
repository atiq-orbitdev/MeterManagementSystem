import logo from './logo.svg';
import './App.css';
//import Uploads from './Weather.js';
import Uploads from './Upload';
function App() {
  return (
    /*<div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
      <Uploads/>
    </div>*/
    <div className="App">
    <header className="App-header">
      {/* <img src={logo} className="App-logo" alt="logo" /> */}
      {/* <p>
        Edit <code>src/App.js</code> and save to reload.
      </p> */}
      {/* <a
        className="App-link"
        href="https://reactjs.org"
        target="_blank"
        rel="noopener noreferrer"
      >
        Learn React
      </a> */}
    </header>
      {Uploads()}
  </div>
  );
}

export default App;
