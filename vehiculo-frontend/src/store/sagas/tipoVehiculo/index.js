import { call, put, takeEvery } from "redux-saga/effects";
import { getCollection } from "../../api/admin/index";
import {
  tipoVehiculoIsFetching,
  tipoVehiculoRequestData,
  tipoVehiculoRequestDataSuccess,
  tipoVehiculoRequestError,
} from "../../slices/tipoVehiculo/tipoVehiculo";

function* getCollectionWorker(action) {
  yield put(tipoVehiculoIsFetching(true));
  try {
     const tipoVehiculo = yield call(getCollection("tipoVehiculo"));
   

    if (tipoVehiculo && tipoVehiculo.data.length !== 0) {
      yield put(tipoVehiculoRequestDataSuccess(tipoVehiculo.data));
    }
  } catch (e) {
    yield put(tipoVehiculoRequestError(e));
  }
}

function* tipoVehiculoSaga() {
  yield takeEvery(tipoVehiculoRequestData, getCollectionWorker);
}

export default tipoVehiculoSaga;
