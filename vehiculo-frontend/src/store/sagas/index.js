import { all } from "redux-saga/effects";

import combustibleSaga from "./combustible";
import marcaSaga from "./marca";
import tipoVehiculoSaga from "./tipoVehiculo";
import transmisionSaga from "./transmision";
import vehiculoSaga from "./vehiculo";

export default function* rootSaga() {
  yield all([
    combustibleSaga(),
    combustibleSaga(),
    marcaSaga(),
    tipoVehiculoSaga(),
    transmisionSaga(),
    vehiculoSaga(),
  ]);
}
