import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor() { }

  get authApiURL() {
    return 'https://localhost:5001/api';
  }
}
