import Topbar from "./components/Topbar";

const Drawer = ({ children }) => {
  return (
    <div className="min-h-full">
      <Topbar />
      {children}
    </div>
  );
};
export default Drawer;
