import { Component, OnInit } from '@angular/core';
import { WeatherForecast, WeatherForecastClient } from '../web-api-client';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: WeatherForecastClient) { }

  ngOnInit(): void {
    this.getWeatherForecast()
  }

  public getWeatherForecast() {
    this.http.get()
      .subscribe(res => this.forecasts = res)
  }
}

