import { call, put, takeEvery } from "redux-saga/effects";
import { getCollection } from "../../api/admin/index";
import {
  transmisionIsFetching,
  transmisionRequestData,
  transmisionRequestDataSuccess,
  transmisionRequestError,
} from "../../slices/transmision/transmision";

function* getCollectionWorker(action) {
  yield put(transmisionIsFetching(true));
  try {
    const transmision = yield call(getCollection("transmision"));
  

    if (transmision && transmision.data.length !== 0) {
      yield put(transmisionRequestDataSuccess(transmision.data));
    }
  } catch (e) {
    yield put(transmisionRequestError(e));
  }
}

function* transmisionSaga() {
  yield takeEvery(transmisionRequestData, getCollectionWorker);
}

export default transmisionSaga;
