import { call, put, takeEvery } from "redux-saga/effects";
import { getCollection } from "../../api/admin/index";
import {
  marcaIsFetching,
  marcaRequestData,
  marcaRequestDataSuccess,
  marcaRequestError,
} from "../../slices/marca/marca";

function* getCollectionWorker(action) {
  yield put(marcaIsFetching(true));
  try {
    const marca = yield call(getCollection("marca"));

    if (marca && marca.data.length !== 0) {
      yield put(marcaRequestDataSuccess(marca.data));
    }
  } catch (e) {
    yield put(marcaRequestError(e));
  }
}

function* marcaSaga() {
  yield takeEvery(marcaRequestData, getCollectionWorker);
}

export default marcaSaga;
