import React from "react";
import Drawer from "../layout/Drawer";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Car from "../screens/car/Car";

const AppRouter = () => {
  return (
    <Router>
      <Drawer>
        <Routes>
          <Route path="/car" element={<Car />} />
          <Route path="*" element={<Car />} />
        </Routes>
      </Drawer>
    </Router>
  );
};

export default AppRouter;
