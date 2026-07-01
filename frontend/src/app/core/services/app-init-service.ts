import { inject, Injectable } from '@angular/core';
import { DataStorageService } from './data-storage-service';
import { ApiService } from './api-service';

@Injectable({
  providedIn: 'root',
})
export class AppInitService {
  private _dataStorage = inject(DataStorageService)
  private apiService = inject(ApiService)
  
    init(){
    const storedId  = this._dataStorage.getLocalStorageItem('clientId');
    
    if(!storedId){
      let newId = crypto.randomUUID()
      this._dataStorage.setClientId(newId)
      this._dataStorage.setLocalStorageItem('clientId',newId)
      this._dataStorage.saveUser( newId);      
    }
    else{
      this._dataStorage.setClientId(storedId);
    }

    this._dataStorage.loadMapData()
  }

}
