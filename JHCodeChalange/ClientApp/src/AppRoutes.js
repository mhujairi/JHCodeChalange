import { TweetsCount } from "./components/TweetsCount";
import { TopHashTags } from "./components/TopHashTags";
import { Home } from "./components/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/TweetsCount',
        element: <TweetsCount />
    },
    {
        path: '/TopHashtags',
        element: <TopHashTags />
    }
];

export default AppRoutes;
