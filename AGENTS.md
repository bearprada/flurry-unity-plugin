# Agent execution

Read [project memory](PROJECT_MEMORY.md) and [project plan](PROJECT_PLAN.md) before work. Reconcile them with Git and remote issues/PRs.

1. Start each item by checking out `master` and fast-forwarding from `origin/master`, then create a focused task branch/worktree. Preserve existing edits and unpublished commits; use an isolated worktree when necessary.
2. Write acceptance test cases before implementation code. Run a focused test red, implement the smallest change, then run green and relevant regression checks. For documentation/configuration, define artifact checks before editing.
3. Own verification: provision available tools, dependencies, fixtures, mocks, emulators or simulators and run checks yourself. Waiting for verification is actionable work. Record commands, results and evidence; distinguish automated, live and physical-device acceptance.
4. Continue after creating a PR: check its status, update memory and plan, then take the highest-priority independent TODO from fresh `master`. Track pending review/checks and revisit them while working.
5. For subagents, claim an item with owner, branch/worktree, dependencies, acceptance cases and next action. Use independent worktrees; return changed files, commit/PR, test evidence and remaining actions. Reconcile results before closing items.
6. After every item, update memory and plan in the same change. Mark done only against acceptance evidence. Keep incomplete items visible and continue until every agreed TODO is complete. For an external prerequisite tools cannot resolve, record evidence, responsible owner and unblock action, pursue other items, and report the unresolved dependency if nothing executable remains.

Commit/push only intended files. Follow repository PR policy unless the user explicitly requests direct `master` publication; never force-push.
