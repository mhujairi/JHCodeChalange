import React, { Component } from 'react';

export class TopHashTags extends Component {
    static displayName = TopHashTags.name;

    constructor(props) {
        super(props);
        this.state = { hashtags: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderHashTagsTable(hashtags) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Hashag</th>
                        <th>Count</th>
                    </tr>
                </thead>
                <tbody>
                    {hashtags.map(hashtag =>
                        <tr key={hashtag.tag}>
                            <td>{hashtag.tag}</td>
                            <td>{hashtag.count}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : TopHashTags.renderHashTagsTable(this.state.hashtags);

        return (
            <div>
                <h1 id="tableLabel">Top 10 Hashtags</h1>
                {contents}

                <button onClick={async (e) => { await this.populateData() } }>Refresh</button>
            </div>
        );
    }

    async populateData() {
        const response = await fetch('Tweets/TopHashTags/10');
        const data = await response.json();
        this.setState({ hashtags: data, loading: false });
    }
}
