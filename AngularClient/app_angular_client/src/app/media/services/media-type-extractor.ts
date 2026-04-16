import { Injectable } from "@angular/core";
import { InvalidMediaTypeError } from "../errors/invalid-media-type-error";
import { MediaType } from "../media-type";

@Injectable({
  providedIn: 'root'
})
export class MediaTypeExtractor{

  extract(file: File) : MediaType{
    if(file.type.startsWith("image/"))
      return MediaType.image;
    else if(file.type.startsWith("video/"))
      return MediaType.video;
    throw new InvalidMediaTypeError();
  }

}
