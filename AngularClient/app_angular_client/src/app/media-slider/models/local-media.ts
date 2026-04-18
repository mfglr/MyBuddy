import { InvalidMediaTypeError } from "../errors/invalid-media-type-error";
import { Media } from "./media";
import { MediaType } from "./media-type";

export class LocalMedia extends Media{
  file: File;

  constructor(file:File) {
    if(file.type.startsWith("image/"))
      super(MediaType.image);
    else if(file.type.startsWith("video/"))
      super(MediaType.video);
    else
      throw new InvalidMediaTypeError();

    this.file = file;
  }
}
