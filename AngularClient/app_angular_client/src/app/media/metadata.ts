import { Dimension } from "./dimension";

export class Metadata{
  width: number;
  height: number;
  duration: number;

  constructor(width: number, height: number, duration: number) {
    this.width = width;
    this.height = height;
    this.duration = duration;
  }

  getDimention(): Dimension{
    return new Dimension(this.width, this.height);
  }
}
