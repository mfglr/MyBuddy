import { InvalidMediaTypeError } from "./invalid-media-type-error";
import { BaseMedia } from "./base-media";
import { MediaType } from "./media-type";

export class LocalMedia extends BaseMedia{
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
