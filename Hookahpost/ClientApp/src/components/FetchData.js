import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
    this.state = { forecasts: [], loading: true, demo: ''};

    fetch('api/SampleData/WeatherForecasts')
      .then(response => response.json())
        .then(data => { 
        this.setState({ forecasts: data, loading: false});
        });

      fetch('api/SampleData/WeatherForecasts2')
          .then(response => response.json())
          .then(data => {
              console.log(data)
              this.setState({ demo: data, loading: false });
          });
  }

    static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.dateFormatted}>
              <td>{forecast.dateFormatted}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
    }


  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
          : FetchData.renderForecastsTable(this.state.forecasts);

      let a = this.state.loading
          ? <p><em>Loading...</em></p>
          : this.state.demo;
       

    return (
      <div>
            <h1>Weatherrrr forecast</h1>
            <h2>{a}</h2>

        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}

