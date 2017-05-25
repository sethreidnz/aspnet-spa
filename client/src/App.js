    import React, { Component } from 'react';
    import logo from './logo.svg';
    import './App.css';
    import { getValues } from './api/values'

    class App extends Component {
      constructor(){
        super();
        this.state = {
          values: []
        }
      }
      async componentWillMount(){
        var data = await getValues()
        this.setState(({values: data}))
      }
      render() {
        const { values } = this.state
        return (
          <div className="App">
            <div className="App-header">
              <img src={logo} className="App-logo" alt="logo" />
              <h2>Welcome to React</h2>
            </div>
            <ul>
              {values.map((value)=>(
                <li style={{'listStyle': 'none'}} key={value}>
                  {value}
                </li>
              ))}
            </ul>
          </div>
        );
      }
    }

    export default App;