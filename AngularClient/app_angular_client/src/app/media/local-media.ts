import { Media } from "./media";
import { MediaType } from "./media-type";

export class LocalMedia extends Media{
  file: File;

  constructor(type:MediaType, file:File) {
    super(type);
    this.file = file;
  }
}
