import { MediaType } from "./media-type";

export class BaseMedia{
  type: MediaType;
  constructor(type: MediaType){
    this.type = type;
  }
}
