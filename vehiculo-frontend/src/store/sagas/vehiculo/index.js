import { call, put, takeEvery } from "redux-saga/effects";
import { getCollection, post, putApi, remove } from "../../api/admin/index";
import {
  vehiculoIsFetching,
  vehiculoRequestCreate,
  vehiculoRequestData,
  vehiculoRequestDataSuccess,
  vehiculoRequestDelete,
  vehiculoRequestError,
  vehiculoRequestUpdate,
} from "../../slices/vehiculo/vehiculo";

const module = "vehiculo";

function* getCollectionWorker(action) {
  yield put(vehiculoIsFetching(true));
  try {
    const vehiculo = yield call(getCollection(module));

    if (vehiculo && vehiculo.data.length !== 0) {
      yield put(vehiculoRequestDataSuccess(vehiculo.data));
    }
  } catch (e) {
    yield put(vehiculoRequestError(e));
  }
}

function* vehiculoCreateWorker(action) {
  try {
    const vehiculo = yield call(post(module, action.payload));
    if (vehiculo) yield put(vehiculoRequestData());
  } catch (error) {
    console.log(error);
  }
}

function* vehiculoDeleteWorker(action) {
  try {
    yield call(remove(module, action.payload));
    window.location.reload();
  } catch (error) {
    console.log(error);
  }
}

function* vehiculoUpdateWorker(action) {
  console.log(action);
  try {
    const vehiculo = yield call(
      putApi(module, action.payload.id, action.payload)
    );
    if (vehiculo) yield put(vehiculoRequestData());
  } catch (error) {
    console.log(error);
  }
}

function* vehiculoSaga() {
  yield takeEvery(vehiculoRequestData, getCollectionWorker);
  yield takeEvery(vehiculoRequestCreate, vehiculoCreateWorker);
  yield takeEvery(vehiculoRequestDelete, vehiculoDeleteWorker);
  yield takeEvery(vehiculoRequestUpdate, vehiculoUpdateWorker);
}

export default vehiculoSaga;
