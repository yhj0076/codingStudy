#include <sstream>
#include <unordered_map>
#include <string>
#include <vector>

using namespace std;

vector<string> solution(vector<string> record) {
    vector<string> answer;

    unordered_map<string, string> dict;
    vector<pair<string, string>> action_order;
    for (int i = 0; i < record.size(); i++) {
        string input;
        input = record[i];

        stringstream ss(input);

        string action, id, name;
        ss >> action >> id >> name;

        if (action == "Enter") {
            dict[id] = name;
            action_order.push_back(make_pair(action, id));
        }
        else if (action == "Change") {
            dict[id] = name;
        }
        else if (action == "Leave") {
            action_order.push_back(make_pair(action, id));
        }
    }

    for (auto& action : action_order) {
        string action_log;
        if (action.first == "Enter") {
            action_log = dict[action.second]+"님이 들어왔습니다.";
        }
        else if (action.first == "Leave") {
            action_log = dict[action.second]+"님이 나갔습니다.";
        }
        answer.push_back(action_log);
    }
    return answer;
}