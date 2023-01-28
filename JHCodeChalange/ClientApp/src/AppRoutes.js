import { TweetsCount } from "./components/TweetsCount";
import { TopHashTags } from "./components/TopHashTags";

const AppRoutes = [
    {
        index: true,
        element: <TweetsCount />
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
