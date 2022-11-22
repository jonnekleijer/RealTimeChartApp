import { DataPointModel } from "./datapointmodel.model copy";

export interface TimeSerieModel {
  data: DataPointModel[],
  name: string
}
