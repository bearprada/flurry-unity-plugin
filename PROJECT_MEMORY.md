# Project memory

## Reviewed baseline (2026-10-25)

- Flurry Unity SDK plugin; [README](README.md) and [test instructions](Tests/README.md) describe Unity EditMode verification. This repository packages assets rather than a complete Unity Editor project.
- Delivery base: `origin/master` at `3bee724`. Existing checkout has modified plugin/tests/package artifacts and untracked tests; preserve them. Use an isolated worktree for documentation publication because switching that checkout to master is refused by Git.
- Current rollout is documentation-only; Unity/application tests have not been run.

## Handoff contract

Rollout verification: policy-coverage and local-link checks passed across all 13 workspace repositories; `git diff --check` passed. Application testing remains outside this documentation-only change.

After each item record task/owner, branch/worktree, base SHA, changed files, commit/PR, acceptance cases, exact verification commands/results/artifacts, pending external acceptance and next action. Store status in [project plan](PROJECT_PLAN.md); reconcile with Git and remote state on resume.
